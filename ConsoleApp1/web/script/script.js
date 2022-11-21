const { createApp } = Vue
const text ="Lorem ipsum dolor sit amet, consectetur adipisicing elit. Consequuntur minima, vitae ducimus accusantium et totam voluptatum praesentium ratione dolore vel architecto voluptate quae atque quaerat necessitatibus odit iste molestias illo.";

const app = createApp({
    data() {
        return {
            FirstName: "Serhii",          
            LastName: "Kropotov",
            Age: 29,
            tempText: [text,text,text,text,text,text,text]
        }
    },
    methods: {
        click(){            
            console.log(tempText[0])
        },
        addItemToTempText(){
            this.tempText.push(text);
        }
    }
});


document.addEventListener("DOMContentLoaded", ()=>{
    app.mount('#app');
});


