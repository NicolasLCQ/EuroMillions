CREATE TABLE IF NOT EXISTS T_DRAW
(
    ID               INTEGER   PRIMARY KEY AUTOINCREMENT NOT NULL,
    BALL_ONE         INT       not null,
    BALL_TWO         INT       not null,
    BALL_THREE       INT       not null,
    BALL_FOUR        INT       not null,
    BALL_FIVE        INT       not null,
    STAR_ONE                         INT  not null,
    STAR_TWO                         INT  not null,
    WINNING_BALLS_IN_ASCENDING_ORDER TEXT,
    WINNING_STARS_IN_ASCENDING_ORDER TEXT
);
