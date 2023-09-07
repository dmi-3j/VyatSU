package org.example.animals;

public abstract class Inhabbitans extends Animal {
    public Inhabbitans(String name, String type, int age, int maxRunDistance, int maxSwimDistance) {
        super(name, type, age, maxRunDistance, maxSwimDistance);
    }
    public String benefit() {
        if (this.getType() == "Росомаха") return "Росомаха. Они питаются мышевидными грызунами, рябчиками, тетеревами, иногда тем, что осталось от охоты медведей, волков.";
        if (this.getType() == "Выдра") return "Выдра. Питается преимущественно рыбой (сазаном, щукой, форелью, плотвой, бычками и др.), охотно поедает речных моллюсков и личинок ручейников.";
        if (this.getType() == "Заяц") return "Заяц. Зайцы питаются капустой, корнеплодами (любят морковку), едят траву, зимой питаются корой деревьев.";
        else return "Извините, я пока не знаю рацион " + this.getType() + " :(";
    }
}
