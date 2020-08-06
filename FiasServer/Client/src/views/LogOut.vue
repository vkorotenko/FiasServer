<template>
  <div></div>
</template>
<script lang='ts'>
import { UserManager, WebStorageStateStore } from 'oidc-client'
import router from '../router'
window.document.title = 'Waiting...'
/* eslint-disable @typescript-eslint/no-unused-vars */
const mgr = new UserManager({
  userStore: new WebStorageStateStore({ store: window.localStorage })
})
  .signoutRedirectCallback()
  .then(function () {
    router.push('/')
  })
  .catch(function (err) {
    console.log(err)
  })

export default {
  name: 'LogOutCallBack'
}
</script>
