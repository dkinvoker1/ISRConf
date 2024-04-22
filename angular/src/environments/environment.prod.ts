import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'ISRConf',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44320/',
    redirectUri: baseUrl,
    clientId: 'ISRConf_App',
    responseType: 'code',
    scope: 'offline_access ISRConf',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44320',
      rootNamespace: 'ISRConf',
    },
  },
} as Environment;
