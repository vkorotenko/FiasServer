<template>
  <div id='app'>

    <nav class='navbar is-fixed-top has-shadow'>
      <div class="container">
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
            <router-link to='/' class='navbar-item'>
              Поиск
            </router-link>
            <a href="/swagger" class="navbar-item">
              API
            </a>
            <router-link to='/about' class='navbar-item'>
              О программе
            </router-link>
            <router-link v-if='showAdminBoard' to='/admin' class='navbar-item'>Admin Board</router-link>
            <router-link to='/mod' v-if='showModeratorBoard' class='navbar-item'>Moderator Board</router-link>
            <router-link v-if='currentUser' to='/user' class='navbar-item'>User</router-link>
          </div>
          <div class='navbar-end'>
            <template v-if='!currentUser'>
              <router-link to='/register' class='navbar-item'>
                <font-awesome-icon icon='user-plus' />Sign Up
              </router-link>

              <router-link to='/login' class='navbar-item'>
                <font-awesome-icon icon='sign-in-alt' />Login
              </router-link>
            </template>
            <template v-if='currentUser'>
              <router-link to='/profile' class='navbar-item'>
                <font-awesome-icon icon='user' />
                {{ currentUser.username }}
              </router-link>

              <a class='navbar-item' href @click.prevent='logOut'>
                <font-awesome-icon icon='sign-out-alt' />LogOut
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

<script>
export default {
  computed: {
    currentUser () {
      return this.$store.state.auth.user
    },
    showAdminBoard () {
      if (this.currentUser && this.currentUser.roles) {
        return this.currentUser.roles.includes('ROLE_ADMIN')
      }

      return false
    },
    showModeratorBoard () {
      if (this.currentUser && this.currentUser.roles) {
        return this.currentUser.roles.includes('ROLE_MODERATOR')
      }

      return false
    }
  },
  methods: {
    logOut () {
      this.$store.dispatch('auth/logout')
      this.$router.push('/login')
    }
  }
}
</script>
<style scoped>
.main-ctx{
  margin-top: 80px;
}
</style>
