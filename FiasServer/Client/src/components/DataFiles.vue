<template>
  <div>
    <table class='table is-bordered is-striped is-narrow is-hoverable is-fullwidth'>
      <thead>
        <tr>
          <th>versionId</th>
          <th>textVersion</th>
          <!-- <th>fiasCompleteDbfUrl</th> -->
          <th>fiasCompleteXmlUrl</th>
          <!-- <th>fiasDeltaDbfUrl</th> -->
          <th>fiasDeltaXmlUrl</th>
          <!-- <th>kladr4ArjUrl</th> -->
          <!-- <th>kladr47ZUrl</th> -->
          <th>&nbsp;</th>
        </tr>
      </thead>

      <tr v-for='item in items' v-bind:key='item.versionId'>
        <td>{{item.versionId}}</td>
        <td>{{item.textVersion}}</td>
        <!-- <th>
          <a :href='item.fiasCompleteDbfUrl'>fias_dbf</a>
        </th>-->
        <td>
          <a :href='item.fiasCompleteXmlUrl'>fias_xml</a>
        </td>
        <!-- <th>
          <a :href='item.fiasDeltaDbfUrl'>delta_dbf</a>
        </th>-->
        <td>
          <a :href='item.fiasDeltaXmlUrl'>delta_xml</a>
        </td>
        <!-- <th>
          <a :href='item.kladr4ArjUrl'>kladr_arj</a>
        </th>
        <th>
          <a :href='item.kladr47ZUrl'>kladr_7z</a>
        </th>-->
        <td>
          <button class='button is-primary' @click='onDownload("item.versionId")'>Скачать</button>
        </td>
      </tr>
    </table>
  </div>
</template>
<script lang='ts'>
import Vue from 'vue'
import Component from 'vue-class-component'
// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { FilesInfo } from '../common/FilesInfo'

@Component({
  props: {
    items: []
  }
})
export default class DataFiles extends Vue {}
</script>
