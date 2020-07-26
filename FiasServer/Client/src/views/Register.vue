<template>
  <div class='has-text-centered'>
    <div class='card card-container'>
      <img
        id='profile-img'
        src='//ssl.gstatic.com/accounts/ui/avatar_2x.png'
        class='profile-img-card is-rounded'
      />
      <form name='form' @submit.prevent='handleRegister' class='form'>
        <div v-if='!successful'>
          <div class='field'>
            <label for='username' class='label'>Username</label>
            <ValidationProvider v-slot='{ errors }'>
              <div class='control'>
                <input v-model='user.username' type='text' class='input' name='username' />
              </div>
              <span class='is-danger'>{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div class='field'>
            <label for='email' class='label'>Email</label>
            <ValidationProvider v-slot='{ errors }'>
              <div class='control'>
                <input v-model='user.email' type='email' class='input' name='email' />
              </div>
              <span class='is-danger'>{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div class='field'>
            <label for='password' class='label'>Password</label>
            <ValidationProvider v-slot='{ errors }'>
              <div class='control'>
                <input v-model='user.password' type='password' class='input' name='password' />
              </div>
              <span class='is-danger'>{{ errors[0] }}</span>
            </ValidationProvider>
          </div>
          <div class='field'>
            <button class='button is-primary'>Sign Up</button>
          </div>
        </div>
      </form>

      <div
        v-if='message'
        class='alert'
        :class='successful ? "alert-success" : "alert-danger"'
      >{{message}}</div>
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
  name: 'Register',
  data () {
    return {
      user: new { username: '', password: '', email: '' }(),
      submitted: false,
      successful: false,
      message: ''
    }
  },
  computed: {
    loggedIn () {
      return this.$store.state.auth.status.loggedIn
    }
  },
  mounted () {
    if (this.loggedIn) {
      this.$router.push('/profile')
    }
  },
  methods: {
    handleRegister () {
      this.message = ''
      this.submitted = true
      validate(this.user.username, 'required').then(result => {
        if (result.valid) {
          this.$store.dispatch('auth/register', this.user).then(
            data => {
              this.message = data.message
              this.successful = true
            },
            error => {
              this.message =
                (error.response && error.response.data) ||
                error.message ||
                error.toString()
              this.successful = false
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
