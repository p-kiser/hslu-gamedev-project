# TODO

## Player

- [x] Double jump
  - [x] **Fix that FixedUpdate() stizzle**
- [x] Walk & Sprint
  - [ ] **no can sprint while jump, only when a walk onna floor**
- [x] Control direction during jump
- [ ] Health & can die, Game over
  - [x] Health
  - [x] Kill zone beneath level
  - [x] Respeawn
- [ ] Interfaces which other objects can call
  - [ ] Heal
  - [ ] Invincibility
  - [ ] Damage dealt to the player
- [ ] Can collect points & keys
- [X] Spawnpoints
- [x] maek movement compliant wit physics

Optional
- [ ] Player can shoot

## UI

- [ ] Health bar / or whatever ¯\_(ツ)_/¯
- [ ] Collèctables (keys, points)
- [ ] Active powerup (how long it lasts)

## Collétables

- [x] PoC Collectable: Coin 
- [ ] 3 fancy key to collect
- [x] permanent powerups: health potion
  - [ ] it shalleth check if player is at full health or nah
  - [ ] fancy hearty particle system
- [ ] temporary powerups: (movment speed upgrade || jumping skill) && invicibility

Optional
- [ ] Weapon

## Enemies

- [x] Grunt: patrols a cetrain area
  - [ ] Add jumping to one Grunt variant (explicitly called Grump, the one who can't jump is Grunt)
- [x] Tower: shoots at player if in range
  - [ ] **Recycle projectiles for environmental raisons**
- [x] Bomb: Follows player
  - [ ] Has to explode on contact with playeur
- [ ] Collision zone to kill enemies on jumparoo
- [ ] GIB coins when die
- [ ] Two variants for each enemy type

## Sound

- [ ] Adaptive background music
- [ ] Sound effects for different event (taking damage, collect key etc.)

## Juciness

- [ ] Animations for jumping, collecting stuff, killing enemies, dying etc.
  - [x] jumping
  - [ ] landing
  - [ ] get hit
  - [ ] die
  - [ ] running
- [ ] Particle effects
- [ ] Camera shake
- [ ] collectibles must make the game lag

## Level design

- [x] Tutorial Area
- [x] Hub Area
- [x] Normal Area
- [x] Ice Area
- [x] Swamp Area
- [x] 3 different ground materials (normal, slippery, slow)
  - [x] normal
  - [x] slow
  - [x] slippery
- [x] Interaction with objects: boxes, trampolines (bitch), spikes
- [x] Different elevations, tunnels, stairs
- [x] Telieporteur

Eventually optional

- [ ] Lava. The fucking floor is Lava.
- [ ] Insane fucking boss enemy (this is when the player is finally able to shoot)
