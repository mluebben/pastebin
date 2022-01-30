<!--
// SPDX-License-Identifier: GPL-3.0-or-later
//
// Copyright 2022 Matthias Lübben <ml81@gmx.de>
//
-->

<script setup lang="ts">
import { ref, computed } from 'vue'
import PasteBinApi from '../api/pastebinapi'


const pastes = ref([]);

PasteBinApi.getRecentPastes().then(result => {
  console.log('recent pastes data: ', result)
  pastes.value = result
})
</script>

<template>
<div class="container">
  <div class="row">
    <div class="col">

      <table class="table">
        <thead>
          <tr>
            <th>Title</th>
            <th>Language</th>
            <th>Creation date</th>
            <th>Expiration date</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="paste in pastes" :key="paste.id">
            <td><router-link :to="{ name: 'view', params: { id: paste.id } }">{{ paste.title }}</router-link></td>
            <td>{{ paste.language }}</td>
            <td>{{ paste.creationDate }}</td>
            <td>{{ paste.expirationDate }}</td>
          </tr>
        </tbody>
      </table>

    </div>
  </div>
</div>
</template>

<style scoped>

</style>
