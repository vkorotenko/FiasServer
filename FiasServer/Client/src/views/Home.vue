<template>
  <div class='container'>
    <div class='home'>
      <p v-if='isLoggedIn'>User: {{ username }}</p>
      <button class='btn' @click='login' v-if='!isLoggedIn'>Login</button>
      <button class='btn' @click='logout' v-if='isLoggedIn'>Logout</button>
      <button class='btn' @click='getProtectedApiData' v-if='isLoggedIn'>Get API data</button>
    </div>
    <p>
      <ul>
        <li>
          <a href='https://localhost:44385/_configuration/FiasApp'>config</a>
        </li>
        <li>
          <a href='https://localhost:44385/.well-known/openid-configuration'>openid-configuration</a>
        </li>
      </ul>
    </p>
    <div class='field has-addons w100'>
      <div class='control w100 dropdown is-hoverable is-right is-active'>
        <input
          id='autocomplete'
          class='input w100 dropdown-trigger'
          type='text'
          placeholder='Вся Россия. Для поиска города начните набирать его название'
          aria-haspopup='true'
          aria-controls='dropdown-menu'
          asp-for='Query'
        />
      </div>
      <div class='control dropdown is-hoverable is-right'>
        <button class='button' aria-haspopup='true' aria-controls='dropdown-filter'>
          <span class='icon is-small dropdown-trigger'>
            <font-awesome-icon aria-hidden='true' data-icon='th' icon='th' />
          </span>
          <span class='icon is-small'>
            <font-awesome-icon aria-hidden='true' data-icon='angle-down' icon='angle-down' />
          </span>

          <div class='dropdown-menu' id='dropdown-filter' role='menu'>
            <div class='dropdown-content'>
              <a href="#" class='dropdown-item'>
                <span class='icon is-small'>
                  <font-awesome-icon aria-hidden='true' data-icon='home' icon='home' />
                </span>
                <span>One</span>
              </a>
            </div>
          </div>
        </button>
      </div>
    </div>
    <div
      class='dropdown is-active w100 pull-up-autocomplite'
      id='autocomplete_container'
      style='display: none'
    >
      <div class='dropdown-menu w100' id='dropdown-menu' role='menu'>
        <div class='dropdown-content'>
          <ul class='menu-list dropdown-item' id='autocomplete_result' style='display: none;'></ul>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
import AuthService from '../services/auth.service'
const auth = new AuthService()

@Component({})
export default class Home extends Vue {
  get username (): string {
    if (this.currentUser !== undefined) {
      return this.currentUser
    } else { return '' }
  }

  public currentUser: string | undefined = ''
  public accessTokenExpired: boolean | undefined = false
  public isLoggedIn = false

  public searchitems = [
    { id: 1, name: 'name' },
    { id: 2, name: 'name' },
    { id: 3, name: 'name' }
  ];

  public login () {
    auth.login()
  }

  public logout () {
    auth.logout()
  }

  public mounted () {
    auth.getUser().then((user) => {
      if (user !== null) {
        this.currentUser = user.profile.name
        this.accessTokenExpired = user.expired
      }
      console.log(this.currentUser)
      this.isLoggedIn = (user !== null && !user.expired)
    })
  }
}
</script>
