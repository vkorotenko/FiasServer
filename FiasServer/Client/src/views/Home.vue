<template>
  <div class='container'>
    <!-- <p>
      <ul>
        <li>
          <a href='https://localhost:44385/_configuration/FiasApp'>config</a>
        </li>
        <li>
          <a href='https://localhost:44385/.well-known/openid-configuration'>openid-configuration</a>
        </li>
      </ul>
    </p>-->
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
              <a href='#' class='dropdown-item'>
                <span class='icon is-small'>
                  <font-awesome-icon aria-hidden='true' data-icon='home' icon='home' />
                </span>
                <span>Полный список</span>
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

@Component({})
export default class Home extends Vue {
  info = ''
}
</script>
