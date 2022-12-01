function OnClick( x=0, y=145){
scroll({top: 145, left:0, behavior:"smooth"})
};

var accomplishments = document.getElementsByClassName("accomplishments")[0]
accomplishments.addEventListener("click",()=> scroll({top : 1175, left: 0, behavior:"smooth"}))


var contacts = document.getElementsByClassName("contacts")[0]
contacts.addEventListener("click",()=>scroll({top : 300000, left: 0, behavior:"smooth"}))

var about_me = document.getElementsByClassName("about_me")[0]
about_me.addEventListener("click",OnClick)

var ArrowUp_footer = document.getElementsByClassName("ArrowUp_footer")[0]
ArrowUp_footer.addEventListener('click',()=>scroll({top : 0, left: 0, behavior:"smooth"}))

var im_GitHub = document.getElementsByClassName("im_GitHub")[0]
im_GitHub.addEventListener("click", ()=> window.open("https://github.com/Beetroot-001/c-sharp01"))

var im_LinkedIn = document.getElementsByClassName("im_LinkedIn")[0]
im_LinkedIn.addEventListener("click", ()=> window.open("https://www.linkedin.com/feed/"))

var im_Telegram = document.getElementsByClassName("im_Telegram")[0]
im_Telegram.addEventListener("click", () => window.open("https://web.telegram.org/k/"))

var prompt_value = prompt("Hi! What is your name?")
alert('Hi ' + prompt_value + ' ! Nice to meet you!')
