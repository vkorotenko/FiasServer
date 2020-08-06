import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import AuthService from '../services/auth.service'

Vue.use(Router)

const router = new Router({
  mode: 'history',
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/profile',
      name: 'profile',
      meta: {
        isSecure: true
      },
      // lazy-loaded
      component: () => import(/* webpackChunkName: "profile" */'../views/Profile.vue')
    },
    {
      path: '/admin',
      name: 'admin',
      // lazy-loaded
      component: () => import(/* webpackChunkName: "admin" */'../views/Admin.vue'),
      meta: {
        isSecure: true
      }
    },
    {
      path: '/about',
      name: 'about',
      // lazy-loaded
      component: () => import(/* webpackChunkName: "about" */'../views/About.vue')
    },
    {
      path: '/authentication/login-callback',
      name: 'logincallback',
      component: () => import(/* webpackChunkName: "login" */'../views/LoginCallBack.vue')
    },
    {
      path: '/authentication/logout-callback',
      name: 'logoutcallback',
      component: () => import(/* webpackChunkName: "logout" */'../views/LogOut.vue')
    }

  ]
})

router.beforeEach((to, from, next) => {
  const authService: AuthService = new AuthService()

  if (to.matched.some(record => record.meta.isSecure)) {
    // this route requires auth, check if logged in
    // if not, redirect to login page.
    authService.isLoggedIn().then((isLoggedIn: boolean) => {
      if (isLoggedIn) {
        next()
      } else {
        window.console.log('login required')
        next({
          path: '/',
          query: { redirect: to.fullPath }
        })
      }
    })
  } else {
    next()
  }
})
export default router
