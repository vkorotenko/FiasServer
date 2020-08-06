import Vue from 'vue';
import App from './App.vue';
import router from './router';
import store from './store';
import { ValidationProvider } from 'vee-validate';
import { library } from '@fortawesome/fontawesome-svg-core';
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome';
import { faHome, faTh, faAngleDown, faUser, faUserPlus, faSignInAlt, faSignOutAlt } from '@fortawesome/free-solid-svg-icons';
import './styles/app.scss';
import { HamburgerButton } from './common/HamburgerButton';
import { AutoComplite } from './common/AutoComplite';
import NProgress from 'nprogress';
library.add(faHome, faUser, faUserPlus, faSignInAlt, faSignOutAlt, faTh, faAngleDown);
Vue.config.productionTip = false;
Vue.component('ValidationProvider', ValidationProvider);
Vue.component('font-awesome-icon', FontAwesomeIcon);
document.addEventListener('DOMContentLoaded', () => {
    const hamburger = new HamburgerButton();
    /* eslint-disable @typescript-eslint/no-unused-vars */
    const auto = new AutoComplite();
    hamburger.init();
    NProgress.configure({ showSpinner: false });
});
Vue.config.productionTip = false;
new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app');
//# sourceMappingURL=main.js.map