<template>
  <div>
    <h2>Stamm: {{ tribeName }}</h2>
    <div class="card-container">
      <div class="card" style="width: 18rem;" v-for="dwarf in dwarfs" :key="dwarf.name">

        <!--   TEST     -->
        <p>{{dwarf}}</p>

        <app-modal
          :showModal="showModal"
          :targetDwarf="dwarf"
          @close="showModal = false"
          @weaponAdded="notifyApp"
        />
        <!--      <img class="card-img-top" src="" alt="Card image cap">-->
        <div class="card-body">
          <h3 class="card-title" ref="dwarfName">{{ dwarf.name }}</h3>
          <hr>
          <ul class="dwarf-details">
            <li><strong>Alter:</strong> {{ dwarf.age }}</li>
            <li><strong>Waffen:</strong>
              <ul v-for="weapon in dwarf.weapons">
                <li><span>Name: {{ weapon.name }} | Magischer Wert: {{ weapon.magicValue }}</span></li>
              </ul>
            </li>
            <li><strong>Powerfactor:</strong> {{ dwarf.weapons.map(weapon => weapon.magicValue).reduce((accumulator, currentValue) => accumulator + currentValue) }}</li>
          </ul>
          <button class="card-button" @click="showModal = true"><span class="plus-sign">&#43;</span> Waffe</button>
        </div>
      </div>
    </div>
    <button id="backBtn" @click="onClick">Zurück</button>
  </div>
</template>

<script>
  import Modal from './NewWeaponModal.vue';
  export default {
    data() {
      return {
        showModal: false,
      }
    },
    components: { appModal : Modal },
    props: ['tribeName', 'dwarfs'],
    methods: {
      onClick() {
        this.$emit('backBtn')
      },

      notifyApp() {
        this.showModal = false;
        this.$emit('weaponAdded');
      }
    },
  }
</script>

<style scoped>
  .card-container {
    display: flex;
    justify-content: center;
  }
  h2 {
    font-weight: bold;
  }
  .card {
    border: 1px solid #2c3e50;
    border-radius: 5px;
    margin: 5px;
    padding: 4px;
    min-height: 300px;
    position: relative;
  }

  .card-title {
    text-align: left;
    padding-left: 15px;
  }

  .dwarf-details {
    list-style-type: none;
    text-align: left;
  }

  button {
    background-color: #35aa7f;
  }

  .card-button {
    padding: 10px;
    display: block;
    margin-top: 5px;
    position: absolute;
    right: 5px;
    top: 5px;
  }

  #backBtn {
    display: block;
    background-color: chocolate;
    margin: 30px auto;
  }

  .plus-sign {
    font-weight: bolder;
    font-size: x-large;
  }
</style>
