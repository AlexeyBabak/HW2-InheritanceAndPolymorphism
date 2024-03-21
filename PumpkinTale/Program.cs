using PumpkinTale.Factory;
using PumpkinTale.Models;

ICharacterFactory factory = new CharacterFactory();
var pumpkin = new Pumpkin(30);
var tale = new PumpkinTale.PumpkinTale(pumpkin);

tale.AddCharacter(factory.CreateAnimal("Grandfather"));
tale.AddCharacter(factory.CreateAnimal("Grandmother"));
tale.AddCharacter(factory.CreateAnimal("Granddaughter"));
tale.AddCharacter(factory.CreateAnimal("Dog"));

tale.StartTale();
