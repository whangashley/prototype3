-> main
=== main ===
YOU!!! What have you done?
    + [Uhhhh, what do you mean?]
        -> WhatDoYouMean
    + [next level next level next level]
        -> NextLevel

=== WhatDoYouMean ===
You literally just obliterated EVERYONE.
    + [Yeah! Let's make it more of a challenge this next level.]
        -> NextLevel
    + [Sorry about that...]
        -> SorryAboutThat

=== NextLevel ===
...There is no next level. This is it! Enemies are still here, sure. 
And they're gonna stay here DEAD this because of YOU.
    + [Shouldn't the enemies like. Disappear or something?]
        -> EnemiesDisappear
    + [Hey, I'm sorry, ok?]
        -> SorryAboutThat

=== SorryAboutThat ===
Sorry? That's it? Wooooooow. 
Do you hear that? The sound of the saddest, tiniest violin...
    + [Um...]
        -> WaitTheyreDead
    + [Ahahaha! (pls stop omg)]
        -> WaitTheyreDead
    + [CAN I RESTART OR SOMETHING I DIDN'T KNOW LIKE SRSLY DUDE]
        -> WaitTheyreDead

=== WaitTheyreDead ===
Hey everyone, listen up! This guy's SORRY!
Oh wait I forgot they can't listen BECAUSE THEY'RE ALL DEAD.
    + [Man, why are they still here? Shouldn't they have faded away by now?]
        -> EnemiesDisappear
    + [Um...what now...I guess...?]
        -> EnemiesDisappear
    + [Destroy(gameObject)]
        -> DestroySelf

=== DestroySelf ===
Bro did you just try to destroy yourself
    + [it didn't work??? it's broken just like these enemies that wont go away]
        -> EnemiesDisappear
    + [I wish to become one with the bodies...though they don't disappear.]
        -> EnemiesDisappear

=== EnemiesDisappear ===
Things don't just disppear conveniently, ok? Much less CORPSES. 
YOU did this. YOU live with this! 
I would ask you to clean up, but I doubt that banana can do anything. 
    + [So this is it? There's nothing left?]
        -> NothingLeft

=== NothingLeft ===
Yeah. I would say something deep about how this is, like, real world stuff, you feel me?
Buuuut I'm pretty sure you already know that if you kill something...it stays. Something is always left behind.
    + [Yeah.]
        -> Goodbye

=== Goodbye ===
Welp. I'm outta here. Enjoy your corpse-filled void.
    + [Bye...]
        -> END