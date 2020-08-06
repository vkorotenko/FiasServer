<template>
  <div class='container'>
    <div class='field'>
      <label class='label'>Последнее скачивание</label>
      <div class='control'>
        <input
          class='input is-small'
          type='text'
          placeholder='Small input'
          disabled
          :value='content.lastDownload'
        />
      </div>
    </div>
    <div class='field'>
      <label class='label'>Директория с данными</label>
      <div class='control'>
        <input
          class='input is-small'
          type='text'
          placeholder='Small input'
          disabled
          :value='content.dataDir'
        />
      </div>
    </div>
    <DataFiles :items="content.filesInfo" />
    <button class='button' @click='getInfo'>get info</button>
  </div>
</template>
<script lang='ts'>
import { Component, Vue } from 'vue-property-decorator'
import UserService from '../services/admin.service'
import DataFiles from '../components/DataFiles.vue'
@Component({
  components: {
    DataFiles
  }
})
export default class Admin extends Vue {
  content = '';
  public getInfo () {
    UserService.getAdminInfo().then(
      (response) => {
        this.content = response.data
      },
      (error) => {
        this.content =
          (error.response && error.response.data) ||
          error.message ||
          error.toString()
      }
    )
  }

  mounted () {
    this.getInfo()
  }
}
</script>
