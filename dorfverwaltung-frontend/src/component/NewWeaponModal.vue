<template>
  <div>
    <div class="myModal" v-show="showModal">
      <div class="modal-content">
        <span @click="$emit('close')" class="close">&times;</span>
        <h3>Neue Waffe</h3>
        <form>
          <input
            type="text"
            placeholder="Name..."
            v-model="weaponName"
            required
          />
          <input
            type="number"
            placeholder="Magischer Wert..."
            v-model="magicValue"
            required
          />
          <button @click.prevent="onClick">bestätigen</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    data() {
      return {
        weaponName: '',
        magicValue: '',
      }
    },

    props: ['showModal', 'targetDwarf'],

    methods: {
      onClick() {
        if(this.weaponName !== '' &&
          Number.isInteger(+this.magicValue)) {
          let newData = {...this.targetDwarf};
          newData['weapons'] = [
            ...this.targetDwarf['weapons'],
            {
              "name": this.weaponName,
              "magicValue": Number.parseInt(this.magicValue)
            },
          ];

          this.$http.post("https://localhost:5019/api", newData)
            .then(data => data.text())
            .then(text => console.log(text))
            .catch(err => console.log(err));

          this.$emit('weaponAdded');
        } else {
          alert('You should fill all fields validly')
        }
      },
    }
  }
</script>

<style scoped>
  .myModal {
    /*display: none;*/
    z-index: 1;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%; /* Full width */
    height: 100%; /* Full height */
    overflow: auto; /* Enable scroll if needed */
    background-color: rgb(0,0,0); /* Fallback color */
    background-color: rgba(0,0,0,0.4); /* Black w/ opacity */
  }

  .modal-content {
    background-color: #fefefe;
    margin: 40% auto; /* 15% from the top and centered */
    padding: 20px;
    border: 1px solid #888;
    width: 40%; /* Could be more or less, depending on screen size */
  }

  /* The Close Button */
  .close {
    color: #aaa;
    float: right;
    font-size: 28px;
    font-weight: bold;
  }

  .close:hover,
  .close:focus {
    color: black;
    text-decoration: none;
    cursor: pointer;
  }

  button {
    padding: 6px 9px;
    font-size: 0.9rem;
  }

  form {
    display: flex;
    flex-direction: column;
  }

  input {
    padding: 5px;
    margin-bottom: 10px;
  }
</style>
