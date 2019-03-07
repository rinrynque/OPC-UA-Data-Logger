﻿using Opc.Ua;
using Opc.Ua.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace IAADL_Core
{
    public class ServerConnection
    {
            #region Constructors
            /// <summary>
            /// Initializes the object.
            /// </summary>
            public ServerConnection()
            {
                m_CertificateValidation = new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            }
            #endregion

            #region Private Fields
            private ApplicationConfiguration m_configuration;
            private Session m_session;
            private int m_reconnectPeriod = 10;
            private int m_discoverTimeout = 5000;
            private SessionReconnectHandler m_reconnectHandler;
            private CertificateValidationEventHandler m_CertificateValidation;
            private EventHandler m_ReconnectComplete;
            private EventHandler m_ReconnectStarting;
            private EventHandler m_KeepAliveComplete;
            private EventHandler m_ConnectComplete;
            #endregion

            #region Public Members
            /// <summary>
            /// The name of the session to create.
            /// </summary>
            public string SessionName { get; set; }

            /// <summary>
            /// Gets or sets a flag indicating that the domain checks should be ignored when connecting.
            /// </summary>
            public bool DisableDomainCheck { get; set; }

            /// <summary>
            /// The URL displayed in the control.
            /// </summary>
            public string ServerUrl { get; set; } 

            /// <summary>
            /// Whether to use security when connecting.
            /// </summary>
            public bool UseSecurity { get; set; }

            /// <summary>
            /// The locales to use when creating the session.
            /// </summary>
            public string[] PreferredLocales { get; set; }

            /// <summary>
            /// The user identity to use when creating the session.
            /// </summary>
            public IUserIdentity UserIdentity { get; set; }

            /// <summary>
            /// The client application configuration.
            /// </summary>
            public ApplicationConfiguration Configuration
            {
                get { return m_configuration; }

                set
                {
                    if (!Object.ReferenceEquals(m_configuration, value))
                    {
                        if (m_configuration != null)
                        {
                            m_configuration.CertificateValidator.CertificateValidation -= m_CertificateValidation;
                        }

                        m_configuration = value;

                        if (m_configuration != null)
                        {
                            m_configuration.CertificateValidator.CertificateValidation += m_CertificateValidation;
                        }
                    }
                }
            }

            /// <summary>
            /// The currently active session. 
            /// </summary>
            public Session Session
            {
                get { return m_session; }
            }

            /// <summary>
            /// The number of seconds between reconnect attempts (0 means reconnect is disabled).
            /// </summary>
            [DefaultValue(10)]
            public int ReconnectPeriod
            {
                get { return m_reconnectPeriod; }
                set { m_reconnectPeriod = value; }
            }

            /// <summary>
            /// Raised when a good keep alive from the server arrives.
            /// </summary>
            public event EventHandler KeepAliveComplete
            {
                add { m_KeepAliveComplete += value; }
                remove { m_KeepAliveComplete -= value; }
            }

            /// <summary>
            /// Raised when a reconnect operation starts.
            /// </summary>
            public event EventHandler ReconnectStarting
            {
                add { m_ReconnectStarting += value; }
                remove { m_ReconnectStarting -= value; }
            }

            /// <summary>
            /// Raised when a reconnect operation completes.
            /// </summary>
            public event EventHandler ReconnectComplete
            {
                add { m_ReconnectComplete += value; }
                remove { m_ReconnectComplete -= value; }
            }

            /// <summary>
            /// Raised after successfully connecting to or disconnecing from a server.
            /// </summary>
            public event EventHandler ConnectComplete
            {
                add { m_ConnectComplete += value; }
                remove { m_ConnectComplete -= value; }
            }

            /// <summary>
            /// Creates a new session.
            /// </summary>
            /// <returns>The new session object.</returns>
            public async Task<Session> Connect()
            {
                // disconnect from existing session.
                Disconnect();

                // determine the URL that was selected.
                string serverUrl = ServerUrl;

                if (m_configuration == null)
                {
                    throw new ArgumentNullException("m_configuration");
                }

                // select the best endpoint.
                EndpointDescription endpointDescription = CoreClientUtils.SelectEndpoint(serverUrl, UseSecurity, m_discoverTimeout);

                EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
                ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);

                m_session = await Session.Create(
                    m_configuration,
                    endpoint,
                    false,
                    !DisableDomainCheck,
                    (String.IsNullOrEmpty(SessionName)) ? m_configuration.ApplicationName : SessionName,
                    60000,
                    UserIdentity,
                    PreferredLocales);

                // set up keep alive callback.
                m_session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);

                // raise an event.
                DoConnectComplete(null);

                // return the new session.
                return m_session;
            }

            /// <summary>
            /// Creates a new session.
            /// </summary>
            /// <param name="serverUrl">The URL of a server endpoint.</param>
            /// <param name="useSecurity">Whether to use security.</param>
            /// <returns>The new session object.</returns>
            public async Task<Session> Connect(string serverUrl, bool useSecurity)
            {
                return await Connect();
            }

            /// <summary>
            /// Disconnects from the server.
            /// </summary>
            public void Disconnect()
            {
                //UpdateStatus(false, DateTime.UtcNow, "Disconnected");

                // stop any reconnect operation.
                if (m_reconnectHandler != null)
                {
                    m_reconnectHandler.Dispose();
                    m_reconnectHandler = null;
                }

                // disconnect any existing session.
                if (m_session != null)
                {
                    m_session.Close(10000);
                    m_session = null;
                }

                // raise an event.
                DoConnectComplete(null);
            }
            #endregion

            #region Private Methods
            /// <summary>
            /// Raises the connect complete event on the main GUI thread.
            /// </summary>
            private void DoConnectComplete(object state)
            {
                if (m_ConnectComplete != null)
                {
                    //if (this.InvokeRequired)
                    //{
                    //    this.BeginInvoke(new System.Threading.WaitCallback(DoConnectComplete), state);
                    //    return;
                    //}

                    m_ConnectComplete(this, null);
                }
            }

            /// <summary>
            /// Finds the endpoint that best matches the current settings.
            /// </summary>
            private EndpointDescription SelectEndpoint()
            {
                // determine the URL that was selected.
                string discoveryUrl = ServerUrl;

                // return the selected endpoint.
                return CoreClientUtils.SelectEndpoint(discoveryUrl, UseSecurity, m_discoverTimeout);
            }
            #endregion

            #region Event Handlers

            /// <summary>
            /// Handles a keep alive event from a session.
            /// </summary>
            private void Session_KeepAlive(Session session, KeepAliveEventArgs e)
            {
                try
                {
                    // check for events from discarded sessions.
                    if (!Object.ReferenceEquals(session, m_session))
                    {
                        return;
                    }

                    // start reconnect sequence on communication error.
                    if (ServiceResult.IsBad(e.Status))
                    {
                        if (m_reconnectPeriod <= 0)
                        {
                            //UpdateStatus(true, e.CurrentTime, "Communication Error ({0})", e.Status);
                            return;
                        }

                        //UpdateStatus(true, e.CurrentTime, "Reconnecting in {0}s", m_reconnectPeriod);

                        if (m_reconnectHandler == null)
                        {
                            if (m_ReconnectStarting != null)
                            {
                                m_ReconnectStarting(this, e);
                            }

                            m_reconnectHandler = new SessionReconnectHandler();
                            m_reconnectHandler.BeginReconnect(m_session, m_reconnectPeriod * 1000, Server_ReconnectComplete);
                        }

                        return;
                    }

                    // update status.
                    //UpdateStatus(false, e.CurrentTime, "Connected [{0}]", session.Endpoint.EndpointUrl);

                    // raise any additional notifications.
                    if (m_KeepAliveComplete != null)
                    {
                        m_KeepAliveComplete(this, e);
                    }
                }
                catch (Exception exception)
                {
                    //ClientUtils.HandleException(this.Text, exception);
                }
            }

            /// <summary>
            /// Handles a reconnect event complete from the reconnect handler.
            /// </summary>
            private void Server_ReconnectComplete(object sender, EventArgs e)
            {
                try
                {
                    // ignore callbacks from discarded objects.
                    if (!Object.ReferenceEquals(sender, m_reconnectHandler))
                    {
                        return;
                    }

                    m_session = m_reconnectHandler.Session;
                    m_reconnectHandler.Dispose();
                    m_reconnectHandler = null;

                    // raise any additional notifications.
                    if (m_ReconnectComplete != null)
                    {
                        m_ReconnectComplete(this, e);
                    }
                }
                catch (Exception exception)
                {
                    //ClientUtils.HandleException(this.Text, exception);
                }
            }

            /// <summary>
            /// Handles a certificate validation error.
            /// </summary>
            private void CertificateValidator_CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
            {
                try
                {
                    e.Accept = m_configuration.SecurityConfiguration.AutoAcceptUntrustedCertificates;

                    if (!m_configuration.SecurityConfiguration.AutoAcceptUntrustedCertificates)
                    {
                        //DialogResult result = MessageBox.Show(
                        //    e.Certificate.Subject,
                        //    "Untrusted Certificate",
                        //    MessageBoxButtons.YesNo,
                        //    MessageBoxIcon.Warning);

                        e.Accept = true;
                    }
                }
                catch (Exception exception)
                {
                    //ClientUtils.HandleException(this.Text, exception);
                }
            }
            #endregion
        }
}
