#include <vector>

int const MAP_X = 18;
int const MAP_Y = 2;

class Object
{
    public:
        int x, y;
        int hp;

    Object(int x, int y, int hp)
    {
        this->x = x;
        this->y = y;
        this->hp = hp;
    }

    virtual void move() = 0;
    ~Object(){}
};

class Monster : public Object
{
    public:
        Monster(int x, int y, int hp) : Object(x, y, hp) {}

        void move()
        {
            if(x!=0)
                x--;
            return;
        }
};

class Bullet : public Object
{
    public:
        Bullet(int x, int y, int hp) : Object(x, y, hp) {}

        void move()
        {
            if(x!=MAP_X-1)
                x++;
            return;
        }
};

class Player : public Object
{
    public:
        Player(int x, int y, int hp) : Object(x, y, hp) {}
        std::vector<Bullet> bullets;

        void move()
        {
            char input = getch();
            switch(input)
            {
                case 'w':
                    if(y == 0)
                        break;
                    y--;
                    break;
                case 's':
                    if(y+1 == MAP_Y)
                        break;
                    y++;
                    break;
                case 'a':
                    if(x == 1)
                        break;
                    x--;
                    break;
                case 'd':
                    if(x+1 == MAP_X)
                        break;
                    x++;
                    break;
                case 'f':
                    fire();
                    break;
            }
            return;
        }

        void fire()
        {
            Bullet bullet(x+1, y, 1);
            bullets.push_back(bullet);
            return;
        }
};
