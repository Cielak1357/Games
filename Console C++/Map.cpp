#include<iostream>
#include "Objects.cpp"

class Map
    {
    private:
        char map[MAP_X][MAP_Y];
    public:
        Map()
        {
            reset();
        }

        void draw()
        {
            for(int i = 0; i < MAP_Y; i++)
            {
                for(int j = 0; j < MAP_X; j++)
                    std::cout << map[j][i];

                std::cout << std::endl;
            }
        }

        void reset()
        {
            for(int i = 0; i < MAP_Y; i++)
                for(int j = 0; j < MAP_X; j++)
                    map[j][i] = '.';
        }

        void putPlayer(Player player)
        {
            map[player.x][player.y] = '@';
        }


        void putMonsters(std::vector<Monster> monsters)
        {
            for(int i = 0; i < monsters.size(); i++)
                map[monsters[i].x][monsters[i].y] = (char)(monsters[i].hp+48); //sign of number in ASCII equals number+48
        }

        void putBullets(std::vector<Bullet> bullets)
        {
            for(int i = 0; i < bullets.size(); i++)
                map[bullets[i].x][bullets[i].y] = '-';
        }
    };
