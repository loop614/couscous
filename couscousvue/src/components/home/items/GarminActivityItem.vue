<script setup lang="ts">
import { type Ref, ref } from 'vue';

type Activity = {
    activityId: number;
    externalActivityId: number;
    activityType: string;
    measurementCount: number;
    metricsCount: number;
    detailsAvailable: boolean;
    minLat: number;
    maxLat: number;
    minLon: number;
    maxLon: number;
}

let loading: Ref<boolean> = ref(true);
let error: Ref<boolean> = ref(false);
let success: Ref<boolean> = ref(false);
let activityData: Ref<Activity | null> = ref<Activity | null>(null);

fetch(`http://localhost:5184/activity/1`)
    .then(res => res.json())
    .then((res: Activity) => {
        console.log(res);
        activityData.value = res;
        success.value = true;
    })
    .catch((e) => {
        console.log(e)
        error.value = true;
    })
    .finally(() => {
        loading.value = false;
    });

</script>

<template>
    <div v-if="loading">Loading...</div>
    <div v-if="error">Something has gone wrong !</div>
    <div v-if="success" style="background-color:#181818">
        <pre>
        {{ activityData }}
        </pre>
    </div>
</template>
