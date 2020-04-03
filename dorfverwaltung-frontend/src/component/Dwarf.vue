<template>
  <div>
    <h2>Stamm: {{ tribeName }}</h2>
    <div class="card-container">
      <div class="card" style="width: 18rem;" v-for="(dwarf, index) in dwarfs">
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
          <button @click="addWeapon(dwarf)">Neue Waffe</button>
        </div>
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
      },
      addWeapon(dwarf) {
        console.log(dwarf['weapons']);
        let newData = {...dwarf};

        newData['weapons'] = [
          ...dwarf['weapons'],
          {
            "name": "Säge",
            "magicValue": 65
          },
        ];

        console.log(newData['weapons']);

        this.$http.post("https://localhost:5019/api", newData)
          .then(data => data.text())
          .then(text => console.log(text))
          .catch(err => console.log(err));
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
