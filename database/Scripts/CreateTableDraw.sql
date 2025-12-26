CREATE TABLE IF NOT EXISTS T_DRAW
(
    ID               INTEGER   PRIMARY KEY AUTOINCREMENT NOT NULL,
    YEAR_DRAW_NUMBER INT       not null,
    DRAW_DATE        DATETIME  not null,
    BALL_ONE         INT       not null,
    BALL_TWO         INT       not null,
    BALL_THREE       INT       not null,
    BALL_FOUR        INT       not null,
    BALL_FIVE        INT       not null,
    STAR_ONE         INT       not null,
    STAR_TWO         INT       not null,
    CONSTRAINT T_DRAW_YEAR_DRAW_NUMBER_uindex UNIQUE (YEAR_DRAW_NUMBER)
);