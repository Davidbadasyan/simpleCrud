<template>
    <v-card>
        <v-card-text>
            <v-row>
                <v-col cols="12" sm="6">
                    <v-text-field v-model="item.code" label="Code" clearable></v-text-field>
                </v-col>
                <v-col cols="12" sm="6">
                    <v-text-field v-model="item.name" label="Name" clearable></v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col cols="12" sm="6">
                    <v-text-field v-model="item.email" label="Email" clearable></v-text-field>
                </v-col>
                <v-col cols="12" sm="6">
                    <v-text-field v-model="item.phone" label="Phone" clearable></v-text-field>
                </v-col>
            </v-row>
            <v-row>
                <v-col cols=12 sm="6">
                    <v-menu v-model="dateInception" close-on-content-click :nudge-right="40" transition="scale-transition"
                        offset-y min-width="auto">
                        <template #activator="{ props }">
                            <v-text-field v-model="item.dateInception" label="Date Inception" prepend-icon="mdi-calendar"
                                readonly v-bind="props">
                                <template #append v-if="item.dateInception">
                                    <v-icon @click="clearDateValue('dateInception')">mdi-close</v-icon>
                                </template>
                            </v-text-field>
                        </template>
                        <v-date-picker v-model="item.dateInception" />
                    </v-menu>
                </v-col>
                <v-col cols=12 sm="6">
                    <v-menu v-model="dateTermination" close-on-content-click :nudge-right="40" transition="scale-transition"
                        offset-y min-width="auto">
                        <template #activator="{ props }">
                            <v-text-field v-model="item.dateTermination" label="Date Termination"
                                prepend-icon="mdi-calendar" readonly v-bind="props">
                                <template #append v-if="item.dateTermination">
                                    <v-icon @click="clearDateValue('dateTermination')">mdi-close</v-icon>
                                </template>
                            </v-text-field>
                        </template>
                        <v-date-picker v-model="item.dateTermination" />
                    </v-menu>
                </v-col>
            </v-row>
            <v-row>
                <v-col cols="12" sm="6">
                    <v-text-field v-model="item.terminationReason" label="Termination Reason" clearable></v-text-field>
                </v-col>
                <v-col cols="12" sm="6">
                    <v-text-field  type="number" v-model="item.idTeam" label="Id Team" clearable></v-text-field>
                </v-col>
            </v-row>
            <v-row class="d-flex justify-end">
                <v-btn type="submit" color="primary" @click="saveItem"> Save</v-btn>
            </v-row>
        </v-card-text>
    </v-card>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { useTable } from '@/stores/table-state';

const route = useRoute();
const router = useRouter();
const table = useTable();
const item = ref<any>({})
const itemId = ref<string>('');
const dateInception = ref(false);
const dateTermination = ref(false);


const clearDateValue = (key: string) => {
    item.value = {
        ...item.value,
        [key]: '',
    };
}

const saveItem = async () => {
    if (itemId.value) {
        await table.updateItem(item.value.id, item.value).then(() => {
            router.push({ name: 'Table' })
        })
    }
    else{
        await table.createItem(item.value).then(() => {
            router.push({ name: 'Table' })
        })
    }
}
onMounted(async () => {
    itemId.value = route.params.id as string;

    if (itemId.value) {
        const res = await table.getById(itemId.value);
        item.value = res?.data;
    }

})

</script>