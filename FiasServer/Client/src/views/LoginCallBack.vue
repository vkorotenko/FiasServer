<template>
  <div></div>
</template>
<script lang='ts'>
import { UserManager, WebStorageStateStore } from 'oidc-client'
window.document.title = 'Waiting...'
/* eslint-disable @typescript-eslint/no-unused-vars */
const mgr = new UserManager({
  userStore: new WebStorageStateStore({ store: window.localStorage })
})
  .signinRedirectCallback()
  .then(function (user) {
    console.log('signin response success', user)
    window.location.href = '/'
  })
  .catch(function (err) {
    console.log(err)
  })

export default {
  name: 'LoginCallBack.vue'
}
</script>
