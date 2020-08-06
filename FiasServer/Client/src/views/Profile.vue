<template>
  <div class='container'>
    <p>
      <strong>Token:</strong>
      {{currentUser.access_token}}
    </p>
    <p>
      <strong>Id:</strong>
      {{currentUser.access_token}}
    </p>
    <p>
      <strong>Name:</strong>
      {{currentUser.profile.name}}
    </p>
    <strong>Authorities:</strong>
    <ul>
      <li v-for='(role,index) in currentUser.roles' :key='index'>{{role}}</li>
    </ul>
  </div>
</template>

<script>
export default {
  name: 'Profile',
  computed: {
    currentUser () {
      return this.$store.state.auth.user
    }
  },
  mounted () {
    if (!this.currentUser) {
      this.$router.push('/login')
    }
  }
}
</script>
