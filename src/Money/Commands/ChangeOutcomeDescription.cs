﻿using Neptuo;
using Neptuo.Commands;
using Neptuo.Models.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Commands
{
    /// <summary>
    /// Changes a <see cref="Description"/> of the outcome with <see cref="OutcomeKey"/>.
    /// </summary>
    public class ChangeOutcomeDescription : Command
    {
        /// <summary>
        /// Gets a key of the outcome to modify.
        /// </summary>
        public IKey OutcomeKey { get; private set; }

        /// <summary>
        /// Gets a new description of the outcome.
        /// </summary>
        public string Description { get; private set; }

        public ChangeOutcomeDescription(IKey outcomeKey, string description)
        {
            Ensure.Condition.NotEmptyKey(outcomeKey);
            Ensure.NotNull(description, "description");
            OutcomeKey = outcomeKey;
            Description = description;
        }
    }
}
