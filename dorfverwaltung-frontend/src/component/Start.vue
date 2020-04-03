<template>
  <div>
    <button v-on:click="fetchData">Stämme</button>
  </div>
</template>

<script>
  export default {
    props: ['tribes', 'dwarfs'],
    methods: {
      // Receive Data From Backend :
      fetchData() {
        this.$http.get('https://localhost:5019/api/dwarfs')
          .then(resp => resp.json()) // Make a JSON File from Server-Response.
          .then(data => data.forEach(dwarf => {
            this.dwarfs.push(dwarf); // Add received data to dwarfs-array
            let alreadyStoredTribe = this.tribes
              .find(tribe => tribe.name === dwarf['tribe']['name']);
            // If the tribe is not already stored, store it into the tibes-array :
            if (!alreadyStoredTribe) {
              this.tribes.push({...dwarf['tribe'], tax: +calculateTax(dwarf['weapons']) })
            } else {
              // If the tribe is already stored just increment the tax by dwarf's powerFactor times 2125 :
              alreadyStoredTribe.tax += +calculateTax(dwarf['weapons']);
            }
          }))
          .catch(e => console.log(e));

        this.$emit('clicked');
      },
    }
  }

  const calculateTax = weapons => {
    const reducer = (accumulator, currentValue) => accumulator + currentValue;
    return (weapons.map(weapon => weapon.magicValue).reduce(reducer)) * 2125
  };
</script>
