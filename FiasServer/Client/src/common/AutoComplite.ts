import { CityItemInterface } from './../models/CityItems'
import NProgress from 'nprogress'

export class AutoComplite {
    url = '/api/address/ru/cities/?query='
    autocomplete: HTMLInputElement
    autocompleteResult: HTMLElement
    resultDiv: HTMLElement
    db: CityItemInterface[] = []
    public constructor () {
      this.autocomplete = document.getElementById('autocomplete') as HTMLInputElement
      this.autocompleteResult = document.getElementById('autocomplete_result') as HTMLElement
      this.resultDiv = document.getElementById('autocomplete_container') as HTMLElement

      if (this.autocomplete !== null) {
        window.console.log('autocomplete')
        this.autocomplete.addEventListener('keyup', this.updPopup)
        this.autocomplete.addEventListener('change', this.updPopup)
        this.autocomplete.addEventListener('focus', this.updPopup)
      }
    }

    private updPopup = async () => {
      if (!this.autocomplete.value) {
        this.popupClearAndHide()
        return
      }
      const a = this.autocomplete.value.trim()
      const parm = this.getParams()
      NProgress.start()
      const response = await fetch(`${this.url}${a}`)
      if (response.ok) { // если HTTP-статус в диапазоне 200-299
        const json = await response.json()
        // window.console.log(json)
        this.db = json
      } else {
        window.console.log('Ошибка HTTP: ' + response.status)
      }
      NProgress.done()
      let c = false
      const b = document.createDocumentFragment()
      for (let x = 0; x < this.db.length; x++) {
        const d: HTMLLIElement = document.createElement('li')
        const item = this.db[x]
        d.classList.add('menu-item')
        const url = `/${parm.filter}/${parm.country}/${item.name}`
        d.innerHTML = `<a href="${url}"><span class="title is-4">${item.name}</span><br><span class="subtitle is-5">${item.parent}</span></a>`

        d.setAttribute('data-name', `${item.name}`)
        d.setAttribute('onclick', 'autocomplete.value=this.dataset.name;autocomplete_result.innerHTML=\'\';autocomplete_container.style.display=\'none\';')
        b.appendChild(d)
      }
      if (this.db.length > 0) { c = true }
      if (c === true) {
        if (this.autocompleteResult !== null) {
          this.autocompleteResult.innerHTML = ''
          this.autocompleteResult.style.display = 'block'
          this.resultDiv.style.display = 'block'
          this.autocompleteResult.appendChild(b)
          return
        }
      }
      this.popupClearAndHide()
    }

    popupClearAndHide (): void {
      this.autocompleteResult.innerHTML = ''
      this.autocompleteResult.style.display = 'none'
      this.resultDiv.style.display = 'none'
    }

    getParams () {
      const ret = {
        filter: 'c',
        country: 'ru',
        city: ''
      }

      const arr = window.location.pathname.split('/').splice(1)
      if (arr.length > 0 && arr[0] !== '') {
        ret.filter = arr[0]
      }
      if (arr.length > 1 && arr[0] !== '') {
        ret.country = arr[1]
      }
      if (arr.length > 2 && arr[0] !== '') {
        ret.city = arr[2]
      }
      return ret
    }
};
