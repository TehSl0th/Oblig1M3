using System;
using System.Collections.Generic;
using System.Text;

namespace M3Oblig1
{
    public class FamilyApp
    {
        public List<Person> _GroupList;
        public string WelcomeMessage = "Dette er en test";
        public string CommandPrompt = "kommando:";

        public FamilyApp(params Person[] GroupList)
        {
            _GroupList = new List<Person>(GroupList);
        }

        public string HandleCommand(string command)
        {
            if (command == "hjelp")
            {
                return HelpCommand();
            }

            if (command == "liste")
            {
                return ListCommand();
            }

            if (command.Contains("vis") && command.Length >4)
            {
                return ShowCommand(command,_GroupList);
            }

            return "";
        }

        private string HelpCommand()
        {
            return @"hjelp => viser en hjelpetekst som forklarer alle kommandoene
liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert. 
vis <id> => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)";
        }

        private string ShowCommand(string input,List<Person>People)
        {
            var Id = Int32.Parse(input.Substring(4));
            for (int i = 0; i < People.Count; i++)
            {
                if (People[i].Id == Id)
                {
                    var fulldescription = "";
                    var children = GetChildren(People[i]);
                    fulldescription+= _GroupList[i].GetDescription();
                    if (children != null)
                    {
                        fulldescription += "\n" + "  Barn:" + "\n";
                        foreach (var child in children)
                        {
                            fulldescription += child.GetChildDescription();
                        }
                    }
                    return fulldescription;
                }
            }
            return "";
        }

        private string ListCommand()
        {
            string liste = string.Empty;
            foreach (var p in _GroupList)
            {
                liste += p.GetDescription() + "\n";
            }
            return liste;
        }
        public Person[] GetChildren(Person person)
        {
            var Children = new List<Person>();

            foreach (var p in _GroupList)
            {
                if (p.Father == person || p.Mother == person)
                {
                    Children.Add(p);
                }
            }

            if (Children.Count <1)
            {
                return null;
            }

            return Children.ToArray();
        }
    }
}
