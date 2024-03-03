<script setup lang="ts">
    import WelcomeItem from './items/WelcomeItem.vue'
    import GarminActivityItem from './items/GarminActivityItem.vue'
</script>

<template>
  <WelcomeItem>
    <template #heading>CousCous Garmin File Explorer</template>
    <template #novel>Here i will show an example of Garmin Smart Watch Data</template>
  </WelcomeItem>
  <GarminActivityItem>
  </GarminActivityItem>
</template>./items/WelcomeItem.vue./items/GarminActivityItem.vue
