<template>
  <div>login</div>
</template>
<script lang='ts'>
window.document.title = 'Waiting...';
import { UserManager, WebStorageStateStore } from 'oidc-client';
const mgr = new UserManager({
  // response_mode: 'query',
  userStore: new WebStorageStateStore({ store: window.localStorage }),
})
  .signinRedirectCallback()
  .then(function (user) {
    console.log('signin response success', user);
    window.location.href = '/';
  })
  .catch(function (err) {
    console.log(err);
  });

export default {
  name: 'LoginCallBack.vue',
};
</script>
