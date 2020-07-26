import { UserManager, WebStorageStateStore } from 'oidc-client';
export default class AuthService {
    constructor() {
        // {"authority":"https://localhost:44385",
        // "client_id":"FiasApp",
        // "redirect_uri":"https://localhost:44385/authentication/login-callback",
        // "post_logout_redirect_uri":"https://localhost:44385/authentication/logout-callback",
        // "response_type":"code",
        // "scope":"FiasServerAPI openid profile"}
        const AUTH0_DOMAIN = 'https://localhost:44385';
        const settings = {
            userStore: new WebStorageStateStore({ store: window.localStorage }),
            authority: AUTH0_DOMAIN,
            /* eslint-disable @typescript-eslint/camelcase */
            client_id: 'FiasApp',
            /* eslint-disable @typescript-eslint/camelcase */
            // redirect_uri: `${AUTH0_DOMAIN}/identity/account/login`,
            redirect_uri: window.location.origin + '/authentication/login-callback',
            post_logout_redirect_uri: `${AUTH0_DOMAIN}/authentication/logout-callback`,
            /* eslint-disable @typescript-eslint/camelcase */
            response_type: 'id_token token',
            automaticSilentRenew: true,
            silent_redirect_uri: `${AUTH0_DOMAIN}/silent-renew.html`,
            // scope: 'FiasServerAPI openid profile customprofile',
            scope: 'openid profile customprofile FiasServerAPI',
            state: 'open',
            filterProtocolClaims: true,
        };
        this.userManager = new UserManager(settings);
    }
    getUser() {
        const user = this.userManager.getUser();
        return user;
    }
    login() {
        return this.userManager.signinRedirect();
    }
    logout() {
        return this.userManager.signoutRedirect();
    }
    async isLoggedIn() {
        const user = await this.getUser();
        return (user !== null && !user.expired);
    }
}
//# sourceMappingURL=auth.service.js.map