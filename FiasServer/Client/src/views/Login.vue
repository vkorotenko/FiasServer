<template>
  <div class='has-text-centered'>
    <div class='card card-container'>
      <img
        id='profile-img'
        src='//ssl.gstatic.com/accounts/ui/avatar_2x.png'
        class='profile-img-card is-rounded'
      />
      <form class='form' name='form' @submit.prevent='handleLogin'>
        <div class='field'>
          <label for='username' class='label'>Username</label>
          <ValidationProvider v-slot='{ errors }'>
            <div class='control'>
              <input v-model='user.username' type='text' class='input' name='username' />
            </div>
            <span>{{ errors[0] }}</span>
          </ValidationProvider>
        </div>
        <div class='field'>
          <label for='password' class='label'>Password</label>
          <ValidationProvider v-slot='{ errors }'>
            <div class='control'>
              <input v-model='user.password' type='password' class='input' name='password' />
            </div>
            <span>{{ errors[0] }}</span>
          </ValidationProvider>
        </div>
        <div class='field'>
          <button class='button is-primary' :disabled='loading'>
            <span v-show='loading' class='spinner-border spinner-border-sm'></span>
            <span>Login</span>
          </button>
        </div>
        <div class='field'>
          <div v-if='message' class='alert alert-danger' role='alert' v-html='message'></div>
        </div>
      </form>
    </div>
  </div>
</template>

<script>
import { validate, extend } from 'vee-validate'

extend('required', {
  validate (value) {
    return {
      required: true,
      valid: ['', null, undefined].indexOf(value) === -1
    }
  },
  computesRequired: true
})

export default {
  name: 'Login',
  data () {
    return {
      user: { username: '', password: '', email: '' },
      loading: false,
      message: ''
    }
  },
  computed: {
    loggedIn () {
      return this.$store.state.auth.status.loggedIn
    }
  },
  created () {
    if (this.loggedIn) {
      this.$router.push('/profile')
    }
  },
  methods: {
    handleLogin () {
      this.loading = true

      validate(this.user.username, 'required').then(result => {
        if (!result.valid) {
          this.loading = false
          return
        }
        if (this.user.username && this.user.password) {
          this.$store.dispatch('auth/login', this.user).then(
            () => {
              this.$router.push('/profile')
            },
            error => {
              this.loading = false
              this.message =
                (error.response && error.response.data) ||
                error.message ||
                error.toString()
            }
          )
        }
      })
    }
  }
}
</script>

<style scoped>
label {
  display: block;
  margin-top: 10px;
}

.card-container.card {
  max-width: 350px !important;
  padding: 40px 40px;
}

.card {
  background-color: #f7f7f7;
  padding: 20px 25px 30px;
  margin: 0 auto 25px;
  margin-top: 50px;
  -moz-border-radius: 2px;
  -webkit-border-radius: 2px;
  border-radius: 2px;
  -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
}

.profile-img-card {
  width: 96px;
  height: 96px;
  margin: 0 auto 10px;
  display: block;
  -moz-border-radius: 50%;
  -webkit-border-radius: 50%;
  border-radius: 50%;
}
</style>
