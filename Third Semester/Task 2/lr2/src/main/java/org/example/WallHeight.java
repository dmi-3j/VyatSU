package org.example;

public enum WallHeight
{
    LOW("Маленькая", 2),MEDIUM("Средняя", 5), HIGH("Высокая", 10);
    private String title;
    private  int height;
    WallHeight(String title, int height) {
        this.title = title;
        this.height = height;
    }

    public String getTitle() {
        return title;
    }

    public int getHeight() {
        return height;
    }
}
