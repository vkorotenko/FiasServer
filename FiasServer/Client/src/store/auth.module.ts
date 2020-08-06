import { User } from 'oidc-client'
const stUser = localStorage.getItem('user')
const user = stUser === null ? null : JSON.parse(stUser)
const initialState = user
  ? { status: { loggedIn: true }, user }
  : { status: { loggedIn: false }, user: null }

export const auth = {
  namespaced: true,
  state: initialState,
  actions: {},
  mutations: {
    loginSuccess (state: { status: { loggedIn: boolean }; user: User | null }, logUser: User | null) {
      state.status.loggedIn = true
      state.user = logUser
    },
    loginFailure (state: { status: { loggedIn: boolean }; user: null }) {
      state.status.loggedIn = false
      state.user = null
    },
    logout (state: { status: { loggedIn: boolean }; user: null }) {
      state.status.loggedIn = false
      state.user = null
    },
    registerSuccess (state: { status: { loggedIn: boolean } }) {
      state.status.loggedIn = false
    },
    registerFailure (state: { status: { loggedIn: boolean } }) {
      state.status.loggedIn = false
    }
  }
}
