import Vue from 'vue'
import Router from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Register from '../views/Register.vue'
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
      path: '/login',
      component: Login
    },
    {
      path: '/register',
      component: Register
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
      component: () => import(/* webpackChunkName: "admin" */'../views/BoardAdmin.vue')
    },
    {
      path: '/user',
      name: 'user',
      // lazy-loaded
      component: () => import(/* webpackChunkName: "user" */'../views/BoardUser.vue')
    },
    {
      path: '/about',
      name: 'about',
      meta: {
        requiresAuth: true
      },
      // lazy-loaded
      component: () => import(/* webpackChunkName: "about" */'../views/About.vue')
    },
    { path: '/api/address' },
    { path: '/authorize' },
    {
      path: '/authentication/login-callback',
      name: 'logincallback',
      component: () => import(/* webpackChunkName: "logincallback" */'../views/LoginCallBack.vue')
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
