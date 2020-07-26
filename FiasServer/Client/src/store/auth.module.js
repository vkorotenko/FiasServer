const stUser = localStorage.getItem('user');
const user = stUser === null ? null : JSON.parse(stUser);
const initialState = user
    ? { status: { loggedIn: true }, user }
    : { status: { loggedIn: false }, user: null };
export const auth = {
    namespaced: true,
    state: initialState,
    actions: {},
    mutations: {
        loginSuccess(state, logUser) {
            state.status.loggedIn = true;
            state.user = logUser;
        },
        loginFailure(state) {
            state.status.loggedIn = false;
            state.user = null;
        },
        logout(state) {
            state.status.loggedIn = false;
            state.user = null;
        },
        registerSuccess(state) {
            state.status.loggedIn = false;
        },
        registerFailure(state) {
            state.status.loggedIn = false;
        }
    }
};
//# sourceMappingURL=auth.module.js.map