<template>
  <div>
    <h2>Stamm: {{ tribeName }}</h2>
    <div class="card" style="width: 18rem;" v-for="dwarf in dwarfs">
<!--      <img class="card-img-top" src="" alt="Card image cap">-->
      <div class="card-body">
        <h3 class="card-title">{{ dwarf.name }}</h3>
        <hr>
        <ul class="dwarf-details">
          <li><strong>Alter:</strong> {{ dwarf.age }}</li>
          <li><strong>Waffen:</strong>
            <ul v-for="weapon in dwarf.weapons">
              <span>{{ weapon.name }} MV: {{ weapon.magicValue }}</span>
            </ul>
          </li>
        </ul>
        <button>Neue Waffe</button>
      </div>
    </div>
    <button id="backBtn" @click="onClick">Zurück</button>
  </div>
</template>

<script>
  export default {
    props: ['tribeName', 'dwarfs'],
    methods: {
      onClick() {
        this.$emit('backBtn')
      }
    }
  }
</script>

<style scoped>
  h2 {
    font-weight: bold;
  }
  .card {
    display: inline-block;
    border: 1px solid #2c3e50;
    border-radius: 5px;
    margin: 5px;
    padding-bottom: 8px;
  }

  .dwarf-details {
    list-style-type: none;
    text-align: left;
  }

  button {
    background-color: #35aa7f;
  }

  #backBtn {
    display: block;
    background-color: chocolate;
    margin: 30px auto;
  }
</style>
