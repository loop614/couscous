<script setup lang="ts">
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

    let loading: boolean = true;
    let error: boolean = false;
    let success: boolean = false;
    let activityData = {} as Activity;

    fetch(`http://localhost:5184/activity/2`)
        .then(res => res.json())
        .then((res: Activity) => {
            console.log(res);
            activityData = res;
            loading = false;
            success = true;

            // until hmr comes alive
            let activityDataContainer: Element | null = document.querySelector("#activityData");
            activityDataContainer!.style.display = "";
            activityDataContainer!.querySelector(".activityDataId")!.innerHTML = activityData.activityId.toString();
            activityDataContainer!.querySelector(".externalActivityId")!.innerHTML = activityData.externalActivityId.toString();
            activityDataContainer!.querySelector(".activityType")!.innerHTML = activityData.activityType;
            activityDataContainer!.querySelector(".measurementCount")!.innerHTML = activityData.measurementCount.toString();
            activityDataContainer!.querySelector(".detailsAvailable")!.innerHTML = activityData.detailsAvailable.toString();
        })
        .catch((e) => {
            console.log(e)
            loading = false;
            error = true;
        });

</script>

<template>
    <!-- <div v-if="loading">Loading...</div>
    <div v-if="error">Something has gone wrong !</div>
    <div v-if="success">{{ activityData }}</div> -->

    <div id="activityData" style="display:none;">
        <p>activityDataId</p><div class="activityDataId"></div>
        <p>externalActivityId</p><div class="externalActivityId"></div>
        <p>activityType</p><div class="activityType"></div>
        <p>measurementCount</p><div class="measurementCount"></div>
        <p>metricsCount</p><div class="metricsCount"></div>
        <p>detailsAvailable</p><div class="detailsAvailable"></div>
    </div>
</template>
