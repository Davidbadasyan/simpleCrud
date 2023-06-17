<template>
    <v-navigation-drawer left>
        <v-list class="pt-4 pr-4" color="transparent">
            <template v-for="(item, i) in sidebarItem" :key="i">
                <v-list-item :to="item.to" rounded="lg" class="mb-1">
                    <v-list-item-title class="v-list-item__title">{{ item.title }}</v-list-item-title>
                </v-list-item>
            </template>
        </v-list>
    </v-navigation-drawer>
</template>

<script setup lang="ts">
import sidebarItem from './sidebarItem';

</script>

<style lang="scss">
.v-navigation-drawer__content{
    .text-transparent {
        color: black !important;
    }
}
</style>