USE DB_EUROMILLIONS;

CREATE TABLE IF NOT EXISTS T_DRAW
(
    ID               int      not null,
    YEAR_DRAW_NUMBER int      not null,
    DRAW_DATE             DATETIME not null,
    BALL_ONE         int      not null,
    BALL_TWO         int      not null,
    BALL_THREE       int      not null,
    BALL_FOUR        int      not null,
    BALL_FIVE        int      not null,
    STAR_ONE         int      not null,
    STAR_TWO         int      not null
);