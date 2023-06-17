<template>
  <v-app>
    <vertical-sidebar />

    <default-view />
  </v-app>
</template>

<script lang="ts" setup>
  import VerticalSidebar from '@/components/vertical-sidebar/VerticalSidebar.vue';
  import DefaultView from './View.vue'
</script>
