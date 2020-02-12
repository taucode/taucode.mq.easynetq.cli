(defblock :name get-subscriber-message-types :is-top t
	(worker
		:worker-name get-subscriber-message-types
		:verb "types"
		:description "Gets message types supported by the subscriber."
		:usage-samples (
			"sub types"))

	(end)
)
