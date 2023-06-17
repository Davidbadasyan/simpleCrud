<!-- eslint-disable vue/valid-v-slot -->
<template>
    <v-card>
        <v-card-title>
            Table
            <v-spacer></v-spacer>
            <v-text-field v-model="search" append-icon="mdi-magnify" label="Search" single-line hide-details />
        </v-card-title>
        <v-data-table :headers="headers" :items="data" :sort-by="[{ key: 'link', order: 'asc' }]" :search="search">
            <template #top>
                <v-toolbar flat>
                    <v-toolbar-title>Notifications</v-toolbar-title>
                    <v-spacer></v-spacer>
                    <v-dialog v-model="dialog" max-width="500px">
                        <template #activator="{ on }">
                            <v-btn color="primary" dark class="mb-2" v-on:click="on" @click="redirectToCreateItem">
                                Create New Item
                            </v-btn>
                        </template>
                    </v-dialog>
                </v-toolbar>
            </template>
            <template #item.actions="{ item }">
                <v-icon size="small" class="me-2" @click="redirectToUpdateItem(item.raw.id)">
                    mdi-pencil
                </v-icon>
                <v-icon size="small" class="me-2" @click="deleteItem(item.raw.id)">
                    mdi-delete
                </v-icon>
            </template>
        </v-data-table>
    </v-card>
</template>

<script setup lang="ts">
import { useTable } from '@/stores/table-state';
import { ref, onMounted } from 'vue';
import { useRouter } from 'vue-router';
const fields = [
    { title: 'Code', align: 'start', key: 'code', },
    { title: 'Name', key: 'name', },
    { title: 'Phone', key: 'phone', sortable: false },
    { title: 'ID Team', key: 'idTeam' },
    { title: 'Date Termination', key: 'dateTermination' },
    { title: 'Actions', align: 'end', key: 'actions', sortable: false },
]
const router = useRouter();
const dialog = ref(false);
const headers = ref([...fields])
const search = ref('')
const table = useTable();
const data = ref([]);
const redirectToCreateItem = () => {
    router.push('/table/add')
}

const redirectToUpdateItem = (id: number) => {
    router.push(`/table/${id}/update`)
}

const deleteItem = async (id: string) => {
    await table.deleteById(id).then(async () => {
       await getTableList()
    })
}


onMounted(async () => {
   await getTableList();
})

const getTableList = async () => {
    try {
        const res = await table.getTableData()
        data.value = res?.data.data
    } catch (err) {
        console.log(err);
    }
}

</script>