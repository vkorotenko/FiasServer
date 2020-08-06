import { UserManager, WebStorageStateStore } from 'oidc-client';
export default class AuthService {
    constructor() {
        const AUTH0_DOMAIN = 'https://localhost:44385';
        /* eslint-disable @typescript-eslint/no-explicit-any */
        const settings = {
            userStore: new WebStorageStateStore({ store: window.localStorage }),
            authority: AUTH0_DOMAIN,
            /* eslint-disable @typescript-eslint/camelcase */
            client_id: 'FiasApp',
            /* eslint-disable @typescript-eslint/camelcase */
            redirect_uri: window.location.origin + '/authentication/login-callback',
            post_logout_redirect_uri: `${AUTH0_DOMAIN}/authentication/logout-callback`,
            /* eslint-disable @typescript-eslint/camelcase */
            response_type: 'id_token token',
            automaticSilentRenew: true,
            silent_redirect_uri: `${AUTH0_DOMAIN}/silent-renew.html`,
            // scope: 'FiasServerAPI openid profile customprofile',
            scope: 'openid profile customprofile FiasServerAPI',
            state: 'open',
            filterProtocolClaims: true
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