using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixObjects : MonoBehaviour
{

    private string pasta = "pasta";
    private string cheese = "cheese";
    private string sausage = "sausage";
    private string pizzacream = "pizzacream";
    private string tomato = "tomato";
    private string bun = "bun";
    private string meatpatty = "meatpatty";
    private string lettuce = "lettuce";

    //pizza kombinációk
    private string pastaWithPizzacream = "pastaWithPizzacream";
    private string pastaWithPizzacreamAndSausage = "pastaWithPizzacreamAndSausage";
    private string pastaWithPizzacreamAndTomato = "pastaWithPizzacreamAndTomato";
    private string pastaWithPizzacreamAndCheese = "pastaWithPizzacreamAndCheese";

    private string pastaWithPizzacreamAndCheeseAndSausage = "pastaWithPizzacreamAndCheeseAndSausage";
    private string pastaWithPizzacreamAndCheeseAndTomato = "pastaWithPizzacreamAndCheeseAndTomato";    
    private string pastaWithPizzacreamAndSausageAndTomato = "pastaWithPizzacreamAndSausageAndTomato";

    private string pastaWithPizzacreamAndSausageAndTomatoAndCheese = "pastaWithPizzacreamAndSausageAndTomatoAndCheese";

    //hamburger kombinációk
    private string bunWithMeatpatty = "bunWithMeatpatty";
    private string bunWithMeatpattyAndCheese = "bunWithMeatpattyAndCheese";
    private string bunWithMeatpattyAndTomato = "bunWithMeatpattyAndTomato";
    private string bunWithMeatpattyAndLettuce = "bunWithMeatpattyAndLettuce";
    
    private string bunWithMeatpattyAndLettuceAndCheese = "bunWithMeatpattyAndLettuceAndCheese";
    private string bunWithMeatpattyAndLettuceAndTomato = "bunWithMeatpattyAndLettuceAndTomato";
    private string bunWithMeatpattyAndTomatoAndCheese = "bunWithMeatpattyAndTomatoAndCheese";

    private string bunWithMeatpattyAndLettuceAndTomatoAndCheese = "bunWithMeatpattyAndLettuceAndTomatoAndCheese";

	public string checkDroppedObject(GameObject grabbedObj, GameObject placedObj){
        Debug.Log(grabbedObj.transform.tag + " : "+ placedObj.transform.tag);
        Debug.Log(pasta + " : : "+ pizzacream);
        string value = "";
        value = createPizza(grabbedObj,placedObj);
        if(value == ""){
            createHamburger(grabbedObj,placedObj);
        }
        return value;
    }


    private string createPizza(GameObject grabbedObj, GameObject placedObj){
        if((placedObj.gameObject.transform.tag == pasta && grabbedObj.gameObject.transform.tag == pizzacream) ||
            (placedObj.gameObject.transform.tag == pizzacream && grabbedObj.gameObject.transform.tag == pasta)){
            return pastaWithPizzacream;
        }
        else if(placedObj.gameObject.transform.tag == pastaWithPizzacream && grabbedObj.gameObject.transform.tag == tomato){
            return pastaWithPizzacreamAndTomato;
        }
        else if(placedObj.gameObject.transform.tag == pastaWithPizzacream && grabbedObj.gameObject.transform.tag == cheese){
            return pastaWithPizzacreamAndCheese;
        }
        else if(placedObj.gameObject.transform.tag == pastaWithPizzacream && grabbedObj.gameObject.transform.tag == sausage){
            return pastaWithPizzacreamAndSausage;
        }
        else if((placedObj.gameObject.transform.tag == pastaWithPizzacreamAndCheese && grabbedObj.gameObject.transform.tag == sausage) ||
                (placedObj.gameObject.transform.tag == pastaWithPizzacreamAndSausage && grabbedObj.gameObject.transform.tag == cheese)
        ){
            return pastaWithPizzacreamAndCheeseAndSausage;
        }
        else if((placedObj.gameObject.transform.tag == pastaWithPizzacreamAndCheese && grabbedObj.gameObject.transform.tag == tomato) ||
                (placedObj.gameObject.transform.tag == pastaWithPizzacreamAndTomato && grabbedObj.gameObject.transform.tag == cheese)
        ){
            return pastaWithPizzacreamAndCheeseAndTomato;
        }
        else if((placedObj.gameObject.transform.tag == pastaWithPizzacreamAndSausage && grabbedObj.gameObject.transform.tag == tomato) ||
                (placedObj.gameObject.transform.tag == pastaWithPizzacreamAndTomato && grabbedObj.gameObject.transform.tag == sausage)
        ){
            return pastaWithPizzacreamAndSausageAndTomato;
        }
        else if((placedObj.gameObject.transform.tag == pastaWithPizzacreamAndCheeseAndSausage && grabbedObj.gameObject.transform.tag == tomato) ||
                (placedObj.gameObject.transform.tag == pastaWithPizzacreamAndCheeseAndTomato && grabbedObj.gameObject.transform.tag == sausage) ||
                (placedObj.gameObject.transform.tag == pastaWithPizzacreamAndSausageAndTomato && grabbedObj.gameObject.transform.tag == cheese)){
                return pastaWithPizzacreamAndSausageAndTomatoAndCheese;
        }
        return "";
    }

    private string createHamburger(GameObject grabbedObj, GameObject placedObj){
        if((placedObj.gameObject.transform.tag == bun && grabbedObj.gameObject.transform.tag == meatpatty) ||
           (placedObj.gameObject.transform.tag == meatpatty && grabbedObj.gameObject.transform.tag == bun)){
            return bunWithMeatpatty;
        }
        if(placedObj.gameObject.transform.tag == bunWithMeatpatty && grabbedObj.gameObject.transform.tag == cheese){
            return bunWithMeatpattyAndCheese;
        }
        if(placedObj.gameObject.transform.tag == bunWithMeatpatty && grabbedObj.gameObject.transform.tag == lettuce){
            return bunWithMeatpattyAndLettuce;
        }
        if(placedObj.gameObject.transform.tag == bunWithMeatpatty && grabbedObj.gameObject.transform.tag == tomato){
            return bunWithMeatpattyAndTomato;
        }
        if((placedObj.gameObject.transform.tag == bunWithMeatpattyAndCheese && grabbedObj.gameObject.transform.tag == tomato) ||
           (placedObj.gameObject.transform.tag == bunWithMeatpattyAndTomato && grabbedObj.gameObject.transform.tag == cheese)){
            return bunWithMeatpattyAndTomatoAndCheese;
        }
        if((placedObj.gameObject.transform.tag == bunWithMeatpattyAndCheese && grabbedObj.gameObject.transform.tag == lettuce) ||
           (placedObj.gameObject.transform.tag == bunWithMeatpattyAndLettuce && grabbedObj.gameObject.transform.tag == cheese)){
            return bunWithMeatpattyAndLettuceAndCheese;
        }
        if((placedObj.gameObject.transform.tag == bunWithMeatpattyAndTomato && grabbedObj.gameObject.transform.tag == lettuce) ||
           (placedObj.gameObject.transform.tag == bunWithMeatpattyAndLettuce && grabbedObj.gameObject.transform.tag == tomato)){
            return bunWithMeatpattyAndLettuceAndTomato;
        }
         else if((placedObj.gameObject.transform.tag == bunWithMeatpattyAndLettuceAndCheese && grabbedObj.gameObject.transform.tag == tomato) ||
                (placedObj.gameObject.transform.tag == bunWithMeatpattyAndLettuceAndTomato && grabbedObj.gameObject.transform.tag == cheese) ||
                (placedObj.gameObject.transform.tag == bunWithMeatpattyAndTomatoAndCheese && grabbedObj.gameObject.transform.tag == lettuce)){
                return bunWithMeatpattyAndLettuceAndTomatoAndCheese;
        }
        return "";

    }
}
