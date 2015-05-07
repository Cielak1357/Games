#include <windows.h>
#include <conio.h>
#include <vector>
#include <ctime>
#include "Map.cpp"

int const monstersSpawnFrequency = 20;
int const monstersMovementFrequency = 10;
int const bulletsMovementFrequency = 3;
int const playerMovementFrequency = 11;

class Game
{
    public:
    Game() : player(1, 0, 1)
    {
        score=0;
        isEnd=false;
        while(!isEnd)
        {
            srand( time( NULL ) );
            update(rand());
            draw();
            elapsedFrames++;
        }
    }
    private:
        Map map;
        Player player;
        std::vector<Monster> monsters;
        int score;
        int elapsedFrames;
        bool isEnd;

        void update(int randomNumber)
        {
            if(elapsedFrames%monstersSpawnFrequency==0)
                createMonsters();

            if(elapsedFrames%monstersMovementFrequency==0)
                for(int i=0; i<monsters.size(); i++)
                    monsters[i].move();

            if(elapsedFrames%playerMovementFrequency==0)
                player.move();

            if(elapsedFrames%bulletsMovementFrequency==0)
            {
                for(int i=0; i<player.bullets.size(); i++)
                    player.bullets[i].move();

                detectCollisions();
            }
            return;
        }

        void draw()
        {
            system("cls");
            map.reset();
            map.putPlayer(player);
            map.putMonsters(monsters);
            map.putBullets(player.bullets);
            map.draw();
            return;
        }

        void createMonsters()
        {
            srand( time( NULL ) );
            int y=rand()%2;
            int hp=rand()%5+1;
            Monster monster(MAP_X-2, y, hp);
            monsters.push_back(monster);
            return;
        }

        void detectCollisions()
        {
            for(int i=0; i<monsters.size(); i++)
            {
                if(isColliding(&(monsters[i]), &player))
                {
                    player.hp--;
                    if(player.hp<=0)
                        fail();
                }

                for(int j=0; j<player.bullets.size(); j++)
                {
                    if(isColliding(&monsters[i], &(player.bullets[j])))
                    {
                        player.bullets[j].hp--;
                        if(player.bullets[j].hp<=0)
                            player.bullets[j].x=MAP_X-1;

                        monsters[i].hp--;
                        if(monsters[i].hp<=0)
                            monsters[i].x=0;

                        scoreUp();
                    }
                }
            }
            return;
        }

        bool isColliding(Object* first, Object* second)
        {
            if(first->x==second->x && first->y==second->y)
                return true;

            return false;
        }

        void fail()
        {
            system("cls");
            std::cout << "GAME OVER!" << std::endl;
            std::cout << "Score: " << score << std::endl;
            Beep(500, 200);
            Beep(500, 200);
            Beep(500, 200);
            system("pause");
            isEnd=true;
            return;
        }

        void scoreUp() {
            score++;
            return;
        }
};
