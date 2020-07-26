import { UserManager, WebStorageStateStore, User } from 'oidc-client'

export default class AuthService {
    private userManager: UserManager;

    constructor () {
      // {"authority":"https://localhost:44385",
      // "client_id":"FiasApp",
      // "redirect_uri":"https://localhost:44385/authentication/login-callback",
      // "post_logout_redirect_uri":"https://localhost:44385/authentication/logout-callback",
      // "response_type":"code",
      // "scope":"FiasServerAPI openid profile"}
      const AUTH0_DOMAIN = 'https://localhost:44385'

      const settings: any = {
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

        // metadata: {
        //      issuer: AUTH0_DOMAIN + '/',
        //      authorization_endpoint: AUTH0_DOMAIN + '/authentication/login-callback',
        // //   // userinfo_endpoint: AUTH0_DOMAIN + '/userinfo',
        //      end_session_endpoint: AUTH0_DOMAIN + '/authentication/logout-callback'
        // //   // jwks_uri: AUTH0_DOMAIN + '/.well-known/jwks.json'
        // }

      }

      this.userManager = new UserManager(settings)
    }

    public getUser (): Promise<User | null> {
      const user = this.userManager.getUser()
      return user
    }

    public login (): Promise<void> {
      return this.userManager.signinRedirect()
    }

    public logout (): Promise<void> {
      return this.userManager.signoutRedirect()
    }

    public async isLoggedIn (): Promise<boolean> {
      const user: User | null = await this.getUser()
      return (user !== null && !user.expired)
    }
}
