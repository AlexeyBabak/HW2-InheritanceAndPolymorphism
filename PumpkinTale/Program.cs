using PumpkinTale.Factory;
using PumpkinTale.Models;

ICharacterFactory factory = new CharacterFactory();
var pumpkin = new Pumpkin(30);
var tale = new PumpkinTale.PumpkinTale(pumpkin);

tale.AddCharacter(factory.CreateCharacter("Grandfather"));
tale.AddCharacter(factory.CreateCharacter("Grandmother"));
tale.AddCharacter(factory.CreateCharacter("Granddaughter"));
tale.AddCharacter(factory.CreateCharacter("Dog"));

tale.StartTale();
