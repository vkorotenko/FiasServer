<template>
  <div id='app'>
    <nav class='navbar is-fixed-top has-shadow'>
      <div class='container'>
        <div class='navbar-brand'>
          <router-link to='/' class='navbar-item'>
            <img class='image' src='./assets/logo.png' />
          </router-link>

          <div class='navbar-burger burger' data-target='navbarExample'>
            <span></span>
            <span></span>
            <span></span>
          </div>
        </div>
        <div id='navbarExample' class='navbar-menu'>
          <div class='navbar-start'>
            <router-link to='/' class='navbar-item'>Поиск</router-link>
            <a href='/swagger' class='navbar-item'>API</a>
            <router-link to='/about' class='navbar-item'>О программе</router-link>
            <router-link v-if='showAdminBoard' to='/admin' class='navbar-item'>Администрирование</router-link>
          </div>
          <div class='navbar-end'>
            <template v-if='!currentUser'>
              <a class='navbar-item' @click='login' v-if='!isLoggedIn'> Вход </a>
            </template>
            <template v-if='currentUser'>
              <router-link to='/profile' class='navbar-item'>
                <font-awesome-icon icon='user' /> {{ currentUser }}
              </router-link>
              <a class='navbar-item' href @click.prevent='logout'>
                <font-awesome-icon icon='sign-out-alt' /> Выход
              </a>
            </template>
          </div>
        </div>
      </div>
    </nav>
    <div class='container main-ctx'>
      <router-view />
    </div>
  </div>
</template>

<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator'
import AuthService from './services/auth.service'
const auth = new AuthService()
@Component({})
export default class App extends Vue {
  get username (): string {
    if (this.currentUser !== undefined) {
      return this.currentUser
    } else {
      return ''
    }
  }

  public currentUser: string | undefined = '';
  public accessTokenExpired: boolean | undefined = false;
  public isLoggedIn = false;
  public login () {
    auth.login()
  }

  public logout () {
    auth.logout()
  }

  get showAdminBoard () {
    const user = this.$store.state.auth.user
    window.console.log(user)
    if (user !== null && user.profile.role === 'Administrator') {
      return true
    }
    return false
  }

  public mounted () {
    auth.getUser().then((user) => {
      if (user !== null) {
        this.$store.state.auth.user = user
        this.currentUser = user.profile.name
        this.accessTokenExpired = user.expired
      }
      this.isLoggedIn = user !== null && !user.expired
    })
  }
}
</script>
<style scoped>
.main-ctx {
  margin-top: 80px;
}
</style>
