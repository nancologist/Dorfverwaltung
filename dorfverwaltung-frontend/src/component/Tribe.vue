<template>
  <div class="tribe-container">
      <div class="tribe-card" v-for="tribe in tribeList">
        <h3>{{ tribe.name }}</h3>
        <p>Seit {{ tribe.since }} nkd</p>
        <p>Steuer {{ tribe.tax }}</p>
        <button @click="onClick">Zwerge</button>
      </div>
  </div>
</template>

<script>
  export default {
    props: ['tribeList'],
    methods: {
      onClick(event) {
        this.$emit("showDwarfs", event)
      }
    }
  }
</script>

<style>
  .tribe-container {
    margin: 2rem 0;
  }

  .tribe-card {
    border: 1px solid #2c3e50;
    display: inline-block;
    border-radius: 5px;
    height: 16rem;
    width: 12rem;
    padding-top: 1rem;
    margin: 0 1rem;
  }
</style>
