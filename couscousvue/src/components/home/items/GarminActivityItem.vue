<script setup lang="ts">
    import { Ref, ref } from 'vue';

    type ActivityMetrics = {
        metricId: number;
        metricValue: number;
        metricKey: string;
    }

    type ActivityGeoPoints = {
        geopointId: number;
        Latitude: number;
        Longitude: number;
        altitude: number;
        timestampPoint: number;
        timerStart: boolean;
        timerStop: boolean;
        distanceFromPreviousPoint: number;
        distanceInMeters: number;
        speed: number;
        cumulativeAscent: number;
        cumulativeDescent: number;
        extendedCoordinate: boolean;
        valid: boolean;
    }

    type Activity = {
        activityId: number;
        externalActivityId: number;
        activityType: string;
        measurementCount: number;
        metricsCount: number;
        detailsAvailable: boolean;
        metrics: ActivityMetrics[];
        geoPoints: ActivityGeoPoints[];
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
            loading.value = false;
            success.value = true;
        })
        .catch((e) => {
            console.log(e)
            loading.value = false;
            error.value = true;
        });

</script>

<template>
    <div v-if="loading">Loading...</div>
    <div v-if="error">Something has gone wrong !</div>
    <div v-if="success">{{ activityData }}</div>
</template>
